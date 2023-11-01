export interface Building {
    id: number;
    name: string;
    location: string;
  }
  
  export interface Object {
    id: number;
    name: string;
  }
  
  export interface DataField {
    id: number;
    name: string;
  }
  
  export interface Reading {
    timestamp: string;
    value: number;
  }