import React, { useState, useEffect } from "react";
import api from "@/api/api";
import { List, ListItemButton, ListItem, ListItemText, Checkbox, Button, Collapse, Stack } from "@mui/material";
import ExpandLess from '@mui/icons-material/ExpandLess';
import ExpandMore from '@mui/icons-material/ExpandMore';

const BodegaSearch = ({ onClose, onSave }) => {
    const [data, setData] = useState([]);
    const [selectedBodegas, setSelectedBodegas] = useState([]);
    const [expandedGroups, setExpandedGroups] = useState({});

    useEffect(() => {
        const fetchData = async () => {
            const result = await api.getBodegas();
            setData(result);
        };

        fetchData();
    }, []);

    const handleBodegaChange = (event, bodegaId) => {
        if (event.target.checked) {
            setSelectedBodegas((prevSelected) => [...prevSelected, bodegaId]);
        } else {
            setSelectedBodegas((prevSelected) =>
                prevSelected.filter((id) => id !== bodegaId)
            );
        }
    };

    const handleGroupClick = (groupId) => {
        setExpandedGroups((prevExpanded) => ({
            ...prevExpanded,
            [groupId]: !prevExpanded[groupId]
        }));
    };

    const handleSave = () => {
        onSave(selectedBodegas);
        onClose();
    };

    const renderBodegas = (bodegas) => {
        return bodegas.map((bodega) => (
            <ListItem
                key={bodega.idBodega}
                disableGutters
                // style={{
                //     paddingLeft: "5px",
                //     marginBottom: "0", // Espacio entre elementos de la lista desplegable
                // }}
                disablePadding
            >
                <Checkbox
                    edge="start"
                    onChange={(event) => handleBodegaChange(event, bodega.idBodega)}
                    checked={selectedBodegas.includes(bodega.idBodega)}
                />
                <ListItemText primary={`${bodega.codigo} - ${bodega.nombre}`} />
            </ListItem>
        ));
    };
    const renderChildren = (children) => {
        return children.map((grupoBodega) => (
            <li key={grupoBodega.idGrupoBodega}>
                <span onClick={() => handleGroupClick(grupoBodega.idGrupoBodega)} style={{ display: 'flex', flexDirection: 'row' }}>
                    {expandedGroups[grupoBodega.idGrupoBodega] ? <ExpandLess /> : <ExpandMore />}
                    {grupoBodega.descripcion}
                </span>
                <Collapse in={expandedGroups[grupoBodega.idGrupoBodega]}>
                    {grupoBodega.bodegas.length > 0 && (
                        <List>{renderBodegas(grupoBodega.bodegas)}</List>
                    )}
                    {grupoBodega.children.length > 0 && (
                        <List>{renderChildren(grupoBodega.children)}</List>
                    )}
                </Collapse>
            </li>
        ));
    };

    return (
        <div className="modal">
            <div className="modal-content">
                <h2>Consulta de Bodegas</h2>
                <List>{renderChildren(data)}</List>
                <Stack spacing={2} direction="row">
                    <Button variant="contained" color="primary" onClick={handleSave}>Seleccionar</Button>
                    <Button variant="contained" color="secondary" onClick={onClose}>Cerrar</Button>
                </Stack>
            </div>
        </div>
    );
};

export default BodegaSearch;
