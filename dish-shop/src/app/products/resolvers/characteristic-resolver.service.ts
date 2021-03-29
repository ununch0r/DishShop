import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Characteristic } from '../../models/characteristic.model';
import { CharacteristicService } from '../http-services/characteristic-service';

@Injectable()
export class CharacteristicResolverService implements Resolve<Characteristic[]>{
    constructor(private characteristicService: CharacteristicService){}

    resolve(route : ActivatedRouteSnapshot, state : RouterStateSnapshot){
            console.log('resolve');
            return this.characteristicService.getAllCharacteristics();
    }
}