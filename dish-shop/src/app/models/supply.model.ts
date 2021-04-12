import { SupplyStatus } from './supply-status.model'
import { ShopNestedEmployee } from './shop-nested-models/shop-nested-employee.model'
import { SupplyContent } from './supply-content.model'
import { Contract } from './contract.model'
import { Shop } from './shop.model'

export class Supply{
    id : number
    dateCreated : Date
    dateReceived : Date
    dateCanceled : Date
    status : SupplyStatus
    totalPrice : number
    creator : ShopNestedEmployee
    receiver : ShopNestedEmployee
    canceller : ShopNestedEmployee
    contract : Contract
    shop : Shop
    suppliesContents : SupplyContent[]
}