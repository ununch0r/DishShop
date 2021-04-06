import { City } from './city.model'
import { ShopNestedEmployee } from './shop-nested-models/shop-nested-employee.model'


export class Shop{
    id : number
    phoneNumber : string
    streetName : string
    streetIdentifier : string
    city : City
    manager : ShopNestedEmployee
    employees : ShopNestedEmployee[]
}