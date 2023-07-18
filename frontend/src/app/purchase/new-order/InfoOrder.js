"use client";
import * as React from "react";
import { styled } from "@mui/material/styles";
import { Box, Paper, Grid, Typography } from "@mui/material";

// Components
import ProveedorSearch from "@/components/ProveedorSearch";
import LaboratorioSearch from "@/components/LaboratorioSearch";
import BodegaSearch from "@/components/BodegaSearch";
import LineaItemSearch from "@/components/LineaItemSearch";

const Item = styled(Paper)(({ theme }) => ({
  backgroundColor: theme.palette.mode === "dark" ? "#1A2027" : "#fff",
  ...theme.typography.body2,
  padding: theme.spacing(1),
  textAlign: "center",
  color: theme.palette.text.secondary,
}));

export default function InfoOrder() {
  return (
    <Box
      component="form"
      // noValidate
      autoComplete="off"
    >
      <Grid container spacing={2}>
        <Grid item xs={12} md={12}>
          <Typography variant="h6">Solicitar A:</Typography>
        </Grid>
        <Grid item xs={6}>
          <ProveedorSearch />
        </Grid>
        <Grid item xs={6}>
          <LaboratorioSearch />
        </Grid>
      </Grid>
    </Box>
  );
}
