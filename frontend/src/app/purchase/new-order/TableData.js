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

import api from '@/api/api';

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
                    <TableRow key={`${row.idItem}-${itemXBodega.idBodega}`}>
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
    ),
    precio: PropTypes.number.isRequired,
    tipoItem: PropTypes.string.isRequired,
    aplicaIva: PropTypes.string.isRequired,
  }).isRequired,
};


export default function TableData() {
  const [rows, setRows] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      const params = {
        "fechaIni": "2023-06-01",
        "fechaFin": "2023-06-30",
        "idClasif1": 12,
        "bodegas": [
          1, 2, 3
        ]
      }

      const result = await api.getItems(params);
      setRows(result);
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
