import { SupplyStatus } from './supply-status.model'

export class Supply{
    id : number
    dateCreated : Date
    dateReceived : Date
    status : SupplyStatus
    totalPrice : number
}