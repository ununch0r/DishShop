import { City } from './city.model'
import { Supply } from './supply.model'
import { ShopAvailabilities } from './shop-availability.model'
import { ShopNestedEmployee } from './shop-nested-models/shop-nested-employee.model'


export class Shop{
    id : number
    phoneNumber : string
    streetName : string
    streetIdentifier : string
    city : City
    manager : ShopNestedEmployee
    employees : ShopNestedEmployee[]
    shopsAvailabilities : ShopAvailabilities[]
    supplies : Supply[]
}