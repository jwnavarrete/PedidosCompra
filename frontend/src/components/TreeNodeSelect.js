import React from "react";
import {
  FormControl,
  InputLabel,
  Select,
  MenuItem 
} from "@mui/material";

import {  TreeView, TreeItem } from '@mui/lab';

import { BiChevronRight, BiChevronDown } from "react-icons/bi";

const TreeNodeSelect = ({ data, onChange }) => {
  const renderTreeItem = (nodes) => {
    return nodes.map((node) => (
      <TreeItem
        key={node.idNodoClasif1}
        nodeId={node.idNodoClasif1}
        label={node.descripcion}
        onChange={onChange}
      >
        {node.children.length > 0 && renderTreeItem(node.children)}
      </TreeItem>
    ));
  };

  return (
    <>
      <TreeView
        aria-label="file system navigator"
        defaultCollapseIcon={<BiChevronDown />}
        defaultExpandIcon={<BiChevronRight />}
        sx={{ height: 240, flexGrow: 1, maxWidth: 400, overflowY: "auto" }}
      >
        {renderTreeItem(data)}
      </TreeView>      
    </>
  );
};

export default TreeNodeSelect;
