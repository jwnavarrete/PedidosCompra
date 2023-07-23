class API {
    constructor() {
      this.host = "https://localhost"; // Cambia el host aquí
      this.port = "7041"; // Cambia el puerto aquí
    }
  
    async getProveedores() {
      const res = await fetch(`${this.host}:${this.port}/api/Proveedor`);
      return res.json();
    }

    async getLineas() {
      const res = await fetch(`${this.host}:${this.port}/api/Linea`);
      return res.json();
    };

    async getBodegas() {
      const res = await fetch(`${this.host}:${this.port}/api/GrupoBodega/bodegas`, { next: { revalidate: 10 } });
      return res.json();
    };

    async getItems(params){
      const res = await fetch(`${this.host}:${this.port}/api/Item`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(params),
      });
      return res.json();
    };
  }
  
  const api = new API();
  export default api;
  