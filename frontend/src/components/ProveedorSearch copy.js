import React, { useEffect, useState } from "react";
import { FormControl, InputLabel, Select, MenuItem } from "@mui/material";

import proveedoresData from './proveedores.json';

const getProveedores = async () => {
  const res = await fetch("http://localhost:7042/api/Proveedor");
  return res.json();
};

export default function ProveedorSearch() {
  const [proveedor, setProveedor] = useState([]);
  const [data, setData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      // const result = await getProveedores();
      // setData(result);

      setData(proveedoresData);
    };

    fetchData();
  }, []);

  const handleChange = (event) => {    
    setProveedor(event.target.value);
  };

  return (
    <FormControl fullWidth>
      <InputLabel id="demo-simple-select-label">Proveedor</InputLabel>
      <Select
        labelId="demo-simple-select-label"
        id="demo-simple-select"
        value={proveedor}
        label="Proveedor"
        onChange={handleChange}
      >
        {data.map(({ idProveedor, nombreCompleto }) => (
          <MenuItem key={idProveedor} value={idProveedor}>
            {nombreCompleto}
          </MenuItem>
        ))}
      </Select>
    </FormControl>
  );
}
