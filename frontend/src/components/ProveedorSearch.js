import React, { useEffect, useState } from "react";
import {
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  TextField,
  Autocomplete,
} from "@mui/material";

import proveedoresData from "./proveedores.json";

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
    <>
      <Autocomplete
        disablePortal
        id="combo-box-demo"
        options={data}
        getOptionLabel={(option) => option.nombreCompleto}
        renderInput={(params) => <TextField {...params} label="Movie" />}
      />
    </>
  );
}
