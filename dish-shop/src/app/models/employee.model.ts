import { Position } from './position.model'
import { Shop } from './shop.model'

export class Employee{
    id : number
    firstName : string
    lastName : string
    phoneNumber : string
    email : string
    position : Position
    shop : Shop
}