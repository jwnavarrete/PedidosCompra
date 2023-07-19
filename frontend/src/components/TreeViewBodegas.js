import React, { useState } from 'react';
import { TreeView, TreeItem } from '@mui/lab';
import { Typography } from '@mui/material';

const data = [
  {
    "id_grupo_bodega": 1,
    "codigo": 1,
    "descripcion": "prueba",
    "parent_id": null,
    "children": [
      {
        "id_grupo_bodega": 2,
        "codigo": 2,
        "descripcion": "demo",
        "parent_id": 1,
        "bodegas": [
          {
            "codigo": "BOD1",
            "nombre": "BODEGA 1"
          },
          {
            "codigo": "BOD2",
            "nombre": "BODEGA 2"
          }
        ]
      }
    ]
  },
  {
    "id_grupo_bodega": 3,
    "codigo": 3,
    "descripcion": "prueba 2",
    "parent_id": null,
    "children": [
      {
        "id_grupo_bodega": 3,
        "codigo": 4,
        "descripcion": "demo",
        "parent_id": 3,
        "bodegas": [
          {
            "codigo": "BOD1",
            "nombre": "BODEGA 1"
          },
          {
            "codigo": "BOD2",
            "nombre": "BODEGA 2"
          }
        ]
      }
    ]
  }
];

const TreeViewBodegas = () => {
  const [selectedBodega, setSelectedBodega] = useState(null);

  const handleBodegaSelect = (event, bodegaCodigo) => {
    setSelectedBodega(bodegaCodigo);
  };

  const renderTree = (nodes) => (
    <TreeItem
      key={nodes.id_grupo_bodega}
      nodeId={nodes.id_grupo_bodega.toString()}
      label={nodes.descripcion}
      onLabelClick={(event) => handleBodegaSelect(event, nodes.codigo)}
    >
      {Array.isArray(nodes.children) ? nodes.children.map((node) => renderTree(node)) : null}
      {nodes.bodegas &&
        nodes.bodegas.map((bodega) => (
          <TreeItem
            key={bodega.codigo}
            nodeId={bodega.codigo}
            label={
              <Typography color={selectedBodega === bodega.codigo ? 'primary' : 'inherit'}>
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