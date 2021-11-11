using API.Commands;
using API.EventHandlersInterfaces;
using AutoMapper;
using Core.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.EventHandlers
{
    public class TestRegisteredHandler : ICollectionEventHandler<TestRegistered, TestRegistered>
    {
        private readonly IFighterRepository _fighterRepository;
        private readonly IIsolationBubbleRepository _isolationBubbleRepository;
        private readonly ICovidTestRepository _covidTestRepository;
        private readonly IMapper _mapper;

        public TestRegisteredHandler(
            IFighterRepository fighterRepository,
            IIsolationBubbleRepository isolationBubbleRepository,
            ICovidTestRepository covidTestRepository,
            IMapper mapper)
        {
            _fighterRepository = fighterRepository;
            _isolationBubbleRepository = isolationBubbleRepository;
            _covidTestRepository = covidTestRepository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<TestRegistered>> HandleRequestAsync(TestRegistered request)
        {
            var fighter = await _fighterRepository.SelectFighterWithTestsHistoryAsync(request.FighterId);
            var isolationBubble = await _isolationBubbleRepository.SelectByIdAsync(request.IsolationBubbleId);
            var fighterTests = await _covidTestRepository.SelectCovidTestsForFighterAsync(request.FighterId);

            var tests = new List<CovidTest>();
            var mappedTests = new List<TestRegistered>();

            CovidTest ownTest, bubbleTest;
            
            if (fighter.TestHistory.Count == 0)
            {
                ownTest = await RegisterOwnTest(fighter, isolationBubble, request.IsPositive);
                tests.Add(ownTest);
            }
            bubbleTest = await RegisterBubbleTest(fighter, isolationBubble);

            tests.Add(bubbleTest);
            tests.ForEach(t => mappedTests.Add(_mapper.Map<CovidTest, TestRegistered>(t)));

            return mappedTests;
        }

        private async Task<CovidTest> RegisterOwnTest(Fighter fighter, IsolationBubble isolationBubble, bool isPositive)
        {
            CovidTest fighterTest = new CovidTest()
            {
                FighterId = fighter.Id,
                IsPositive = isPositive,
                IsolationBubbleId = isolationBubble.Id,
                TestDate = DateTime.Today
            };
            await _covidTestRepository.InsertAsync(fighterTest);

            fighterTest.IsolationBubble = isolationBubble;

            return fighterTest;
        }

        private async Task<CovidTest> RegisterBubbleTest(Fighter fighter, IsolationBubble isolationBubble)
        {
            CovidTest onTheSpotTest = new CovidTest()
            {
                FighterId = fighter.Id,
                IsPositive = new Random().Next(0, 100) >= 90,
                IsolationBubbleId = isolationBubble.Id,
                TestDate = DateTime.Today
            };
            await _covidTestRepository.InsertAsync(onTheSpotTest);

            onTheSpotTest.IsolationBubble = isolationBubble;

            return onTheSpotTest;
        }
    }
}
