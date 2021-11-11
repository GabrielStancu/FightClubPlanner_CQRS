import { FighterComponent } from './fighter-component.model';
import { FighterDecorator } from './fighter-decorator.model';

export class NotTestedFighter extends FighterDecorator{
    constructor(fighterComponent: FighterComponent){
        super(fighterComponent);
    }

    fighterColor = '#6c757d'; // gray

    stringToColor(): string{
        return this.fighterColor;
    }
}
