import { Category } from './category.model'
import { Producer } from './producer.model'
import { ProductCharacteristic } from './product-characteristic.model'

export class Product{
    id : number
    name : string
    description : string
    price : number
    category : Category
    producer : Producer
    scanCode : string
    productsCharacteristics : ProductCharacteristic []

    constructor(id:number, name:string, description:string, price:number){
        this.id = id;
        this.name = name;
        this.description = description;
        this.price = price
    }
}