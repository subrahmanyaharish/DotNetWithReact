import { ShoppingCart } from "@mui/icons-material";
import {
  AppBar,
  Badge,
  Box,
  IconButton,
  List,
  ListItem,
  Switch,
  Toolbar,
  Typography,
} from "@mui/material";
import { NavLink } from "react-router-dom";

interface IHeader {
  darkMode: boolean;
  handleThemeChange: () => void;
}

const midLinks = [
  { path: "/catalog", title: "catalog" },
  { path: "/about", title: "about" },
  { path: "/contact", title: "contact" },
];

const rightLinks = [
  { path: "/login", title: "login" },
  { path: "/register", title: "register" },
];

const Header: React.FC<IHeader> = (props) => {
  let activeClassName = "underline";

  return (
    <AppBar position="static" sx={{ mb: 4 }}>
      <Toolbar
        sx={{
          display: "flex",
          justifyContent: "space-between",
          alignItems: "center",
        }}
      >
        <Box display="flex" alignItems="center">
          <Switch checked={props.darkMode} onChange={props.handleThemeChange} />
          <Typography
            sx={{ color: "inherit", textDecoration: "none" }}
            variant="h6"
            component={NavLink}
            to="/"
          >
            Ch-Store
          </Typography>
        </Box>

        <List sx={{ display: "flex" }}>
          {midLinks.map(({ title, path }) => (
            <ListItem
              sx={{
                color: "inherit",
                typography: "h6",
                "&:hover": { color: "secondary.main" },
                "&.active": { color: "secondary.main" },
              }}
              key={path}
            >
              <NavLink style={{ color: "white" }} to={path}>
                {title.toUpperCase()}
              </NavLink>
            </ListItem>
          ))}
        </List>

        <Box display="flex" alignItems="center">
          <IconButton size="large" sx={{ color: "inherit" }}>
            <Badge badgeContent={4} color="secondary">
              <ShoppingCart />
            </Badge>
          </IconButton>

          <List sx={{ display: "flex" }}>
            {rightLinks.map(({ title, path }) => (
              <ListItem sx={{ color: "white", typography: "h6" }} key={path}>
                <NavLink
                  className={({ isActive }) =>
                    isActive ? activeClassName : undefined
                  }
                  style={{ color: "white" }}
                  to={path}
                >
                  {title.toUpperCase()}
                </NavLink>
              </ListItem>
            ))}
          </List>
        </Box>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
