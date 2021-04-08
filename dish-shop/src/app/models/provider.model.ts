import { City } from './city.model'
import { Contract } from './contract.model'

export class Provider{
    id : number
    name : string
    phoneNumber : string
    email : string
    city : City
    contracts : Contract []
}