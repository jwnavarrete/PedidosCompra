import React, { useState, useEffect } from "react";
import { useTheme } from "@mui/material/styles";
import {
  OutlinedInput,
  InputLabel,
  MenuItem,
  FormControl,
  Select,
  Checkbox,
  TextField,
  Autocomplete,
} from "@mui/material";

// icons
import { GrCheckbox, GrCheckboxSelected } from "react-icons/gr";
// import { TbCheckbox } from "react-icons/tb";

import bodegasData from "./bodegas.json";

const icon = <GrCheckbox fontSize="small" />;
const checkedIcon = <GrCheckboxSelected fontSize="small" />;

const ITEM_HEIGHT = 48;
const ITEM_PADDING_TOP = 8;
const MenuProps = {
  PaperProps: {
    style: {
      maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
      width: 250,
    },
  },
};

function getStyles(name, bodegaName, theme) {
  return {
    fontWeight:
      bodegaName.indexOf(name) === -1
        ? theme.typography.fontWeightRegular
        : theme.typography.fontWeightMedium,
  };
}

const getData = async () => {
  const res = await fetch("http://localhost:7042/api/Bodega");
  return res.json();
};

export default function BodegaSearch() {
  const theme = useTheme();
  const [bodegaName, setBodegaName] = React.useState([]);

  const [data, setData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      // const result = await getData();
      // setData(result);

      setData(bodegasData);
    };

    fetchData();
  }, []);

  const handleChange = (event) => {
    const {
      target: { value },
    } = event;

    setBodegaName(
      // On autofill we get a stringified value.
      typeof value === "string" ? value.split(",") : value
    );
  };

  return (
    <>
      <Autocomplete
        multiple
        id="checkboxes-tags-demo"
        options={data}
        disableCloseOnSelect
        getOptionLabel={(option) => option.codigo}
        renderOption={(props, option, { selected }) => (
          <li {...props}>
            <Checkbox
              icon={icon}
              checkedIcon={checkedIcon}
              style={{ marginRight: 8 }}
              checked={selected}
            />
            {option.nombreCompleto}
          </li>
        )}
        style={{ width: 500 }}
        renderInput={(params) => (
          <TextField {...params} label="Bodegas" placeholder="Favorites" />
        )}
      />
      {/* <FormControl fullWidth>
        <InputLabel id="demo-multiple-name-label">Bodega</InputLabel>
        <Select
          labelId="demo-multiple-name-label"
          id="demo-multiple-name"
          multiple
          value={bodegaName}
          onChange={handleChange}
          input={<OutlinedInput label="Bodega" />}
          MenuProps={MenuProps}
        >
          {data.map(({ idBodega, nombreCompleto }) => (
            <MenuItem
              key={idBodega}
              value={idBodega}
              style={getStyles(nombreCompleto, bodegaName, theme)}
            >
              {nombreCompleto}
            </MenuItem>
          ))}
        </Select>
      </FormControl> */}
    </>
  );
}
