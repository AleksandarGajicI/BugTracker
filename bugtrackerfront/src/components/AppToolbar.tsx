import { AppBar, Button, Grid, IconButton, Toolbar, Typography } from '@material-ui/core';
import MenuIcon from '@material-ui/icons/Menu';
import useStyles from './style/MainStyle';


interface Props {
    toggle: () => void
}

function AppToolbar(props: Props) {

    const classes = useStyles()

    return (
        
            <AppBar 
             position="fixed"
             className={classes.appBar}
            >
                <Toolbar>
                    
                <Grid
                container
                direction="row"
                alignItems="center"
                >
                <Grid
                 item
                 sm={1}
                >
                    <IconButton 
                     edge="start" 
                     className={classes.menuButton} 
                     color="inherit" 
                     aria-label="menu"
                     onClick={() => {props.toggle()}}>
                        <MenuIcon />
                    </IconButton>
                </Grid>
                <Grid
                 item
                 container
                 sm
                >
                    <Typography 
                     variant="h6" 
                     className={classes.title}
                    >
                        BugTracker
                    </Typography>
                </Grid>
                <Grid
                 item
                 sm={2}
                 container
                 justify="flex-end"
                >
                    <Button color="inherit" >Login</Button>
                </Grid>
                </Grid>
                </Toolbar>
            </AppBar>
    )
}

export default AppToolbar