import { ContractContent } from './contract-content.model'


export class Contract {
    id : number
    startDate : Date
    endDate : Date
    contractsContents : ContractContent[]
}