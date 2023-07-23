import React, { useEffect, useState } from "react";
import {  
  TextField,
  Autocomplete,
} from "@mui/material";

import api from "@/api/api"; 

export default function ProveedorSearch() {
  const [proveedor, setProveedor] = useState([]);
  const [data, setData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      const result = await api.getProveedores();
      setData(result);
    };

    fetchData();
  }, []);

  const handleChange = (event) => {
    setProveedor(event.target.value);
  };

  return (
    <>
      <Autocomplete
        disablePortal
        id="combo-box-demo"
        options={data}
        getOptionLabel={(option) => option.nombreCompleto}
        renderInput={(params) => <TextField {...params} label="Proveedor" />}
      />
    </>
  );
}
