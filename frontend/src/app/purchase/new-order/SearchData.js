"use client";
import * as React from "react";
import { styled } from "@mui/material/styles";
import { Box, Paper, Grid, Typography, Button } from "@mui/material";

// Components
import ProveedorSearch from "@/components/ProveedorSearch";
import LaboratorioSearch from "@/components/LaboratorioSearch";
import BodegaSearch from "@/components/BodegaSearch";
import LineaItemSearch from "@/components/LineaItemSearch";
import InputDate from "@/components/InputDate";

const Item = styled(Paper)(({ theme }) => ({
  backgroundColor: theme.palette.mode === "dark" ? "#1A2027" : "#fff",
  ...theme.typography.body2,
  padding: theme.spacing(1),
  textAlign: "center",
  color: theme.palette.text.secondary,
}));

export default function SearchData() {
  return (
    <Box
      component="form"
      // noValidate
      autoComplete="off"
    >
      <Grid container spacing={2}>
        <Grid item xs={12} md={12}>
          <Typography variant="p">Filtros</Typography>
        </Grid>
        <Grid item xs={6}>
          <LineaItemSearch />
        </Grid>
        <Grid item xs={6}>
          <BodegaSearch />
        </Grid>
        <Grid item xs={6} md={3}>
          <InputDate />
        </Grid>
        <Grid item xs={6} md={3}>
          <InputDate />
        </Grid>
        <Grid item xs={6} md={6}>
          <Button color="primary" variant="contained" size="small">Buscar</Button>
          
        </Grid>
      </Grid>
    </Box>
  );
}
