import { Drawer, MenuItem, MenuList, Toolbar } from '@material-ui/core';
import useStyles from './style/MainStyle';
import AppRoutes from '../components/AppRoutes';
import { NavLink } from 'react-router-dom';

interface Props {
    isOpen: boolean
}

function MyDrawer(props: Props) {

    const classes = useStyles()
    

    return(
        <Drawer
       anchor="left"
       open={props.isOpen}
       variant="persistent"
       className={classes.drawer}
       classes={{
         paper: classes.drawerPaper,
       }}
      >
        <Toolbar/>
        <MenuList>
            {AppRoutes.map((prop, key) => {
              return (
                <NavLink 
                 to={prop.path} 
                 key={key}
                 style={{ textDecoration: 'none', color: "#000  " }}
                >
                  <MenuItem>
                    {prop.sidebarName}
                  </MenuItem>
                </NavLink>
              )
            })}
        </MenuList>
      </Drawer>
    )
}

export default MyDrawer