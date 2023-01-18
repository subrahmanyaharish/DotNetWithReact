import {
  Avatar,
  Grid,
  List,
  ListItem,
  ListItemAvatar,
  ListItemText,
} from "@mui/material";
import React from "react";
import { Product } from "../../app/models/Product";
import ProductCard from "./ProductCard";

interface IProductList {
  products: Product[];
}

const ProductList: React.FC<IProductList> = (props) => {
  return (
    <Grid container spacing={4}>
      {props.products.map((product, index) => {
        return (
          <Grid item md={3} xs={6} key={product.id}>
            <ProductCard product={product}  />
          </Grid>
        );
      })}
    </Grid>
  );
};

export default ProductList;
