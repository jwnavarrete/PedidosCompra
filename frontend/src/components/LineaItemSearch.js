import React, { useEffect, useState } from "react";
import { FormControl, InputLabel, Select, MenuItem } from "@mui/material";

import lineasData from './lineas_nodos.json';
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
      <TreeNodeSelect data={data} onChange={handleChange} />
      {selectedNode && (<p>Node seleccionado: {selectedNode}</p>)}
    </>
  );
}
