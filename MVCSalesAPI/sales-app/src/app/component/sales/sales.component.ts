import { Component, OnInit } from '@angular/core';
import {SalesService} from '../../services/sales.service'
import {Sales} from '../../models/Sales'
import { Http, Response, Headers } from '@angular/http';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.css']
})
export class SalesComponent implements OnInit {
  ctrl = this
  newSale: Sales
  salesList: Sales[]
  searchQuery: string
  buttonAction: string = "add"
  
  
  constructor(private service: SalesService,private http: Http) { }

  ngOnInit() {
      this.searchQuery = ""
      this.resetForm()
    this.getAllSales()
  }

  getAllSales(){
    this.service.getAllSales(this.searchQuery).subscribe((response)=>{
      this.salesList = response.json()
    })
  }

  selectSale(sale){
      this.newSale = sale
      this.buttonAction = "edit"

  }

  saveSale() {
      if (this.buttonAction == "add") {
        this.service.addSale(this.newSale)
        .then(() => this.getAllSales())
    }
    else{
      this.service.updateSale(this.newSale)
      .then(()=>this.getAllSales())
      }
      this.resetForm()
      this.buttonAction = "add"

    
  }

  deleteSale(sale){
    this.service.deleteSale(sale)
    .then(()=>this.getAllSales())
  }

  resetForm() {
      this.buttonAction = "add"
    this.newSale = {
      id:null,
      FOLIO_NUMBER: "",
      SALE_DATE: "",
      SALE_AMOUNT: ''
    }
  }

}
