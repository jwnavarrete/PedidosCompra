import React, { useEffect, useState } from "react";
import { FormControl, InputLabel, Select, MenuItem } from "@mui/material";

const getLaboratorio = async () => {
  const res = await fetch("http://localhost:7042/api/Laboratorio");
  return res.json();
};

export default function LaboratorioSearch() {
  const [laboratorio, setLaboratorio] = useState([]);
  const [data, setData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      // const result = await getLaboratorio();
      // setData(result);
    };

    fetchData();
  }, []);

  const handleChange = (event) => {    
    setLaboratorio(event.target.value);
  };

  return (
    <FormControl fullWidth>
      <InputLabel id="demo-simple-select-label">Laboratorio</InputLabel>
      <Select
        labelId="demo-simple-select-label"
        id="demo-simple-select"
        value={laboratorio}
        label="Laboratorio"
        onChange={handleChange}
      >
        {data.map(({ idLaboratorio, nombreLaboratorio }) => (
          <MenuItem key={idLaboratorio} value={idLaboratorio}>
            {nombreLaboratorio}
          </MenuItem>
        ))}
      </Select>
    </FormControl>
  );
}
