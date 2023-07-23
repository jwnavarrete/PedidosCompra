import React, { useEffect, useState } from "react";
import { FormControl, InputLabel, Select, MenuItem } from "@mui/material";

import TreeViewLinea from "./TreeViewLinea";

import api from '@/api/api'

export default function LineaItemSearch() {
  const [selectedNode, setSelectedNode] = useState(null);
  const [data, setData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      const result = await api.getLineas();
      setData(result);      
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
          <TreeViewLinea data={data} onChange={handleChange} />
          {selectedNode && <p>Node seleccionado: {selectedNode}</p>}         
        </Select>
      </FormControl>
    </>
  );
}
