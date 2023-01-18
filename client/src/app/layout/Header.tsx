import { PropaneSharp } from "@mui/icons-material";
import { AppBar, Switch, Toolbar, Typography } from "@mui/material";

interface IHeader {
  darkMode: boolean;
  handleThemeChange: () => void;
}

const Header: React.FC<IHeader> = (props) => {
  return (
    <AppBar position="static" sx={{ mb: 4 }}>
      <Toolbar>
        <Switch checked={props.darkMode} onChange={props.handleThemeChange} />
        <Typography variant="h6">Ch-Store</Typography>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
