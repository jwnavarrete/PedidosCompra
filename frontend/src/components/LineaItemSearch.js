import React, { useEffect, useState } from "react";
import { FormControl, InputLabel, Select, MenuItem } from "@mui/material";

import lineasData from "./lineas_nodos.json";
import TreeNodeSelect from "./TreeNodeSelect";

const getData = async () => {
  const res = await fetch("http://localhost:7042/api/Linea");
  return res.json();
};

export default function LineaItemSearch() {
  const [selectedNode, setSelectedNode] = useState(null);
  const [data, setData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      // const result = await getData();
      // setData(result);

      setData(lineasData);
    };

    fetchData();
  }, []);

  const handleChange = (event) => {
    setSelectedNode(event.target.value);
  };

  return (
    <>
      <FormControl fullWidth>
        <InputLabel id="demo-simple-select-label">Linea</InputLabel>
        <Select
          labelId="demo-simple-select-label"
          id="demo-simple-select"
          // value={proveedor}
          label="Linea"
          // onChange={handleChange}
        >
          <TreeNodeSelect data={data} onChange={handleChange} />
          {selectedNode && <p>Node seleccionado: {selectedNode}</p>}

          {/* {data.map(({ idProveedor, nombreCompleto }) => (
          <MenuItem key={idProveedor} value={idProveedor}>
            {nombreCompleto}
          </MenuItem>
        ))} */}
        </Select>
      </FormControl>
    </>
  );
}
