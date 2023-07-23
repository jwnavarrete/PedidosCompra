"use client";
import React, { useState } from "react";
import { styled } from "@mui/material/styles";
import { Box, Paper, Grid, Typography, Button, Modal, TextField } from "@mui/material";

// Components
import ProveedorSearch from "@/components/ProveedorSearch";
import LaboratorioSearch from "@/components/LaboratorioSearch";
import BodegaSearch from "@/components/BodegaSearch";
import LineaItemSearch from "@/components/LineaItemSearch";
import InputDate from "@/components/InputDate";

import SearchIcon from '@mui/icons-material/Search';

const Item = styled(Paper)(({ theme }) => ({
  backgroundColor: theme.palette.mode === "dark" ? "#1A2027" : "#fff",
  ...theme.typography.body2,
  padding: theme.spacing(1),
  textAlign: "center",
  color: theme.palette.text.secondary,
}));

export default function SearchData() {
  const [showModal, setShowModal] = useState(false);
  const [selectedBodegas, setSelectedBodegas] = useState([]);

  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  const handleOpenModal = (event) => {
    event.preventDefault();
    setShowModal(true);
  };

  const handleCloseModal = () => {
    setShowModal(false);
  };

  const handleSaveBodegas = (bodegas) => {
    setSelectedBodegas(bodegas);
  };

  const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: { md: 600, sx: 370 },
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    p: 4,
  };

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
          <TextField
            label="Bodegas"
            variant="outlined"
            value={selectedBodegas?.join(', ')}
            fullWidth
            onClick={() => handleOpen()}
            readOnly // Si deseas que el TextField sea de solo lectura
          />
          <Modal
            open={open}
            onClose={handleClose}
            aria-labelledby="modal-modal-title"
            aria-describedby="modal-modal-description"
          >
            <Box sx={style}>
              <BodegaSearch
                onClose={handleClose}
                onSave={handleSaveBodegas}
              />
            </Box>
          </Modal>
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
