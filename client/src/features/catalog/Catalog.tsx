import Button from "@mui/material/Button";
import { useEffect, useState } from "react";
import { Product } from "../../app/models/Product";
import ProductList from "./ProductList";

interface ICatalog {}

const Catalog: React.FC<ICatalog> = (props) => {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    fetch("https://localhost:7125/api/Products")
      .then((response) => response.json())
      .then((data) => setProducts([...data]));
  }, []);

  return (
    <>
      <ProductList products={products} />
      <Button variant="contained">Add Product</Button>
    </>
  );
};

export default Catalog;
