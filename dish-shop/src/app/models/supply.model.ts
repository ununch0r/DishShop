import { SupplyStatus } from './supply-status.model'
import { ShopNestedEmployee } from './shop-nested-models/shop-nested-employee.model'
import { SupplyContent } from './supply-content.model'
import { Contract } from './contract.model'

export class Supply{
    id : number
    dateCreated : Date
    dateReceived : Date
    status : SupplyStatus
    totalPrice : number
    employee : ShopNestedEmployee
    contract : Contract
    suppliesContents : SupplyContent[]
}