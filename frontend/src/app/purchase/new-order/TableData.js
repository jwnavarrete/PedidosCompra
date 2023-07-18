"use client";

import React, { useState, useEffect } from "react";
import PropTypes from "prop-types";
import Box from "@mui/material/Box";
import Collapse from "@mui/material/Collapse";
import IconButton from "@mui/material/IconButton";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Typography from "@mui/material/Typography";
import Paper from "@mui/material/Paper";
// import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';
// import KeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp';
import { AiOutlineArrowUp, AiOutlineArrowDown } from "react-icons/ai";

import itemsData from './items.json';

const getData = async (data) => {
  const res = await fetch("http://localhost:7042/api/Item", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  });
  return res.json();
};

function createData(name, calories, fat, carbs, protein, price) {
  return {
    name,
    calories,
    fat,
    carbs,
    protein,
    price,
    history: [
      {
        date: "2020-01-05",
        customerId: "11091700",
        amount: 3,
      },
      {
        date: "2020-01-02",
        customerId: "Anonymous",
        amount: 1,
      },
    ],
  };
}

function Row(props) {
  const { row } = props;
  const [open, setOpen] = useState(false);
 
  return (
    <>
      <TableRow sx={{ "& > *": { borderBottom: "unset" } }}>
        <TableCell>
          <IconButton
            aria-label="expand row"
            size="small"
            onClick={() => setOpen(!open)}
          >
            {open ? <AiOutlineArrowUp /> : <AiOutlineArrowDown />}
          </IconButton>
        </TableCell>
        <TableCell component="th" scope="row">
          {row.descripcion}
        </TableCell>
        <TableCell align="right">{row.codBarra}</TableCell>
        <TableCell align="right">{row.stockActual}</TableCell>
        <TableCell align="right">{row.ventaMes}</TableCell>
        <TableCell align="right">{row.cantidadIngresada}</TableCell>
      </TableRow>
      <TableRow>
        <TableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={6}>
          <Collapse in={open} timeout="auto" unmountOnExit>
            <Box sx={{ margin: 1 }}>
              <Typography variant="h6" gutterBottom component="div">
                Bodegas
              </Typography>
              <Table size="small" aria-label="purchases">
                <TableHead>
                  <TableRow>
                    <TableCell>Bodega</TableCell>
                    <TableCell>Stock</TableCell>
                    <TableCell align="right">Venta</TableCell>
                    <TableCell align="right">Cant. Ingresada</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {row.itemXBodega.map((itemXBodega) => (
                    <TableRow key={itemXBodega.IdBodega}>
                      <TableCell component="th" scope="row">
                        {itemXBodega?.bodega?.nombre}
                      </TableCell>
                      <TableCell>{itemXBodega.stockActual}</TableCell>
                      <TableCell align="right">{itemXBodega.ventaMes}</TableCell>
                      <TableCell align="right">
                        {itemXBodega.cantidadIngresada}
                      </TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </Box>
          </Collapse>
        </TableCell>
      </TableRow>
    </>
  );
}

Row.propTypes = {
  row: PropTypes.shape({
    idItem: PropTypes.number.isRequired,
    descripcion: PropTypes.string.isRequired,
    codBarra: PropTypes.string.isRequired,
    bodegas: PropTypes.arrayOf(
      PropTypes.shape({
        stockActual: PropTypes.number.isRequired,
        ventaMes: PropTypes.number.isRequired,
        cantidadIngresada: PropTypes.number.isRequired,
      })
    ).isRequired,
    precio: PropTypes.number.isRequired,
    tipoItem: PropTypes.string.isRequired,
    aplicaIva: PropTypes.string.isRequired,
  }).isRequired,
};

// const rows = [
//   createData("Frozen yoghurt", 159, 6.0, 24, 4.0, 3.99),
//   createData("Ice cream sandwich", 237, 9.0, 37, 4.3, 4.99),
//   createData("Eclair", 262, 16.0, 24, 6.0, 3.79),
//   createData("Cupcake", 305, 3.7, 67, 4.3, 2.5),
//   createData("Gingerbread", 356, 16.0, 49, 3.9, 1.5),
// ];

export default function TableData() {
  const [rows, setRows] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      // const result = await getData({
      //   fechaInicio: "2023-06-01",
      //   fechaFin: "2023-06-15",
      //   idClasif1: 12,
      //   bodegas: [1, 2, 3, 4],
      // });

      // setRows(result);

      setRows(itemsData);
    };

    fetchData();
  }, []);

  return (
    <>
      <Box sx={{ margin: 1 }}>
        <Typography variant="h6" gutterBottom component="div">
          Detalle - Pedido de Compra
        </Typography>
      </Box>
      <TableContainer component={Paper}>
        <Table aria-label="collapsible table">
          <TableHead>
            <TableRow>
              <TableCell />
              <TableCell>Producto</TableCell>
              <TableCell align="right">Codigo Barra</TableCell>
              <TableCell align="right">Cant. Vendida</TableCell>
              <TableCell align="right">Stock</TableCell>
              <TableCell align="right">Pedido</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {rows.map((row) => (
              <Row key={row.idItem} row={row} />
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </>
  );
}
