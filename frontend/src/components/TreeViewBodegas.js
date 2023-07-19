import React, { useState } from "react";
import { TreeView, TreeItem } from "@mui/lab";
import { Typography } from "@mui/material";

const data = [
  {
    idGrupoBodega: 1,
    codigo: "9900",
    descripcion: "IMPORTACIONES SELECTAS",
    idPadre: null,
    nivel: 1,
    activo: "S",
    children: [
      {
        idGrupoBodega: 2,
        codigo: "9999",
        descripcion: "POS SIN ASIGNAR",
        idPadre: 1,
        nivel: 2,
        activo: "N",
        children: [],
        bodegas: [],
      },
      {
        idGrupoBodega: 3,
        codigo: "9901",
        descripcion: "CALCETA",
        idPadre: 1,
        nivel: 2,
        activo: "S",
        children: [],
        bodegas: [
          {
            idBodega: 15,
            codigo: "IS015",
            nombre: "CALCETA",
            activo: "S",
            nombreCompleto: "[IS015] - CALCETA",
            idGrupoBodega: 3,
          },
        ],
      },
      {
        idGrupoBodega: 4,
        codigo: "9902",
        descripcion: "CHONE",
        idPadre: 1,
        nivel: 2,
        activo: "S",
        children: [],
        bodegas: [
          {
            idBodega: 5,
            codigo: "IS005",
            nombre: "CHONE",
            activo: "S",
            nombreCompleto: "[IS005] - CHONE",
            idGrupoBodega: 4,
          },
        ],
      },
      {
        idGrupoBodega: 5,
        codigo: "9903",
        descripcion: "JIPIJAPA",
        idPadre: 1,
        nivel: 2,
        activo: "S",
        children: [],
        bodegas: [
          {
            idBodega: 18,
            codigo: "IS018",
            nombre: "JIPIJAPA",
            activo: "S",
            nombreCompleto: "[IS018] - JIPIJAPA",
            idGrupoBodega: 5,
          },
        ],
      },
      {
        idGrupoBodega: 6,
        codigo: "9904",
        descripcion: "MANTA",
        idPadre: 1,
        nivel: 2,
        activo: "S",
        children: [],
        bodegas: [
          {
            idBodega: 2,
            codigo: "IS002",
            nombre: "MULTIBODEGAS",
            activo: "S",
            nombreCompleto: "[IS002] - MULTIBODEGAS",
            idGrupoBodega: 6,
          },
          {
            idBodega: 4,
            codigo: "IS004",
            nombre: "CALLE 13",
            activo: "S",
            nombreCompleto: "[IS004] - CALLE 13",
            idGrupoBodega: 6,
          },
          {
            idBodega: 6,
            codigo: "IS006",
            nombre: "TARQUI",
            activo: "S",
            nombreCompleto: "[IS006] - TARQUI",
            idGrupoBodega: 6,
          },
          {
            idBodega: 14,
            codigo: "IS014",
            nombre: "CONTENEDORES",
            activo: "S",
            nombreCompleto: "[IS014] - CONTENEDORES",
            idGrupoBodega: 6,
          },
          {
            idBodega: 20,
            codigo: "IS020",
            nombre: "SAN MATEO",
            activo: "S",
            nombreCompleto: "[IS020] - SAN MATEO",
            idGrupoBodega: 6,
          },
        ],
      },
      {
        idGrupoBodega: 7,
        codigo: "9905",
        descripcion: "MONTECRISTI",
        idPadre: 1,
        nivel: 2,
        activo: "S",
        children: [],
        bodegas: [
          {
            idBodega: 8,
            codigo: "IS008",
            nombre: "MONTECRISTI",
            activo: "S",
            nombreCompleto: "[IS008] - MONTECRISTI",
            idGrupoBodega: 7,
          },
        ],
      },
      {
        idGrupoBodega: 8,
        codigo: "9906",
        descripcion: "PORTOVIEJO",
        idPadre: 1,
        nivel: 2,
        activo: "S",
        children: [],
        bodegas: [
          {
            idBodega: 1,
            codigo: "IS001",
            nombre: "MATRIZ",
            activo: "S",
            nombreCompleto: "[IS001] - MATRIZ",
            idGrupoBodega: 8,
          },
          {
            idBodega: 3,
            codigo: "IS003",
            nombre: "PLAZA VICTORIA",
            activo: "S",
            nombreCompleto: "[IS003] - PLAZA VICTORIA",
            idGrupoBodega: 8,
          },
          {
            idBodega: 9,
            codigo: "IS009",
            nombre: "AV.NUEVA",
            activo: "S",
            nombreCompleto: "[IS009] - AV.NUEVA",
            idGrupoBodega: 8,
          },
          {
            idBodega: 10,
            codigo: "IS010",
            nombre: "TAMARINDOS",
            activo: "S",
            nombreCompleto: "[IS010] - TAMARINDOS",
            idGrupoBodega: 8,
          },
          {
            idBodega: 12,
            codigo: "IS012",
            nombre: "AV. MANABI",
            activo: "S",
            nombreCompleto: "[IS012] - AV. MANABI",
            idGrupoBodega: 8,
          },
          {
            idBodega: 13,
            codigo: "IS013",
            nombre: "ECU911",
            activo: "S",
            nombreCompleto: "[IS013] - ECU911",
            idGrupoBodega: 8,
          },
          {
            idBodega: 17,
            codigo: "IS017",
            nombre: "CHILE",
            activo: "S",
            nombreCompleto: "[IS017] - CHILE",
            idGrupoBodega: 8,
          },
          {
            idBodega: 19,
            codigo: "IS019",
            nombre: "AV. GUAYAQUIL",
            activo: "S",
            nombreCompleto: "[IS019] - AV. GUAYAQUIL",
            idGrupoBodega: 8,
          },
          {
            idBodega: 21,
            codigo: "DEVOL",
            nombre: "BODEGA DEVOLUCIONES",
            activo: "S",
            nombreCompleto: "[DEVOL] - BODEGA DEVOLUCIONES",
            idGrupoBodega: 8,
          },
        ],
      },
      {
        idGrupoBodega: 9,
        codigo: "9907",
        descripcion: "ROCAFUERTE",
        idPadre: 1,
        nivel: 2,
        activo: "S",
        children: [],
        bodegas: [
          {
            idBodega: 16,
            codigo: "IS016",
            nombre: "ROCAFUERTE",
            activo: "S",
            nombreCompleto: "[IS016] - ROCAFUERTE",
            idGrupoBodega: 9,
          },
        ],
      },
      {
        idGrupoBodega: 10,
        codigo: "9908",
        descripcion: "SANTA ANA",
        idPadre: 1,
        nivel: 2,
        activo: "S",
        children: [],
        bodegas: [
          {
            idBodega: 11,
            codigo: "IS011",
            nombre: "SANTA ANA",
            activo: "S",
            nombreCompleto: "[IS011] - SANTA ANA",
            idGrupoBodega: 10,
          },
        ],
      },
      {
        idGrupoBodega: 11,
        codigo: "9909",
        descripcion: "TOSAGUA",
        idPadre: 1,
        nivel: 2,
        activo: "S",
        children: [],
        bodegas: [
          {
            idBodega: 7,
            codigo: "IS007",
            nombre: "TOSAGUA",
            activo: "S",
            nombreCompleto: "[IS007] - TOSAGUA",
            idGrupoBodega: 11,
          },
        ],
      },
    ],
    bodegas: [],
  },
];

const TreeViewBodegas = () => {
  const [selectedBodega, setSelectedBodega] = useState(null);

  const handleBodegaSelect = (event, bodegaCodigo) => {
    setSelectedBodega(bodegaCodigo);
  };

  const renderTree = (nodes) => (
    <TreeItem
      key={nodes.id_grupo_bodega}
      nodeId={nodes.id_grupo_bodega}
      label={nodes.descripcion}
      onLabelClick={(event) => handleBodegaSelect(event, nodes.codigo)}
    >
      {Array.isArray(nodes.children)
        ? nodes.children.map((node) => renderTree(node))
        : null}
      {nodes.bodegas &&
        nodes.bodegas.map((bodega) => (
          <TreeItem
            key={bodega.codigo}
            nodeId={bodega.codigo}
            label={
              <Typography
                color={selectedBodega === bodega.codigo ? "primary" : "inherit"}
              >
                {bodega.nombre}
              </Typography>
            }
            onLabelClick={(event) => handleBodegaSelect(event, bodega.codigo)}
          />
        ))}
    </TreeItem>
  );

  return (
    <TreeView
      defaultCollapseIcon={<span>-</span>}
      defaultExpandIcon={<span>+</span>}
    >
      {data.map((node) => renderTree(node))}
    </TreeView>
  );
};

export default TreeViewBodegas;
