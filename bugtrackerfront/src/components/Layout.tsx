import {Grid} from '@material-ui/core';
import clsx from 'clsx';
import { useState } from 'react';
import useStyles from './style/MainStyle';
import { useToggle } from './useToggle';
import AppToolbar from './AppToolbar';
import Footer from './Footer';
import MyDrawer from './MyDrawer'

interface Props {
    children: React.ReactNode
}

function Layout(props: Props) {
    const classes = useStyles();
    const [isOpen, setOpen] = useState(false);

    return (
      <Grid
       container
       style={{backgroundColor: "#eeeeee"}}
      >
        <Grid
         item
         sm={12}
        >
          <AppToolbar toggle={() => {setOpen(!isOpen)}}/>
        </Grid>
        <Grid
         item
         sm={12}
         container
        >
          <MyDrawer isOpen={isOpen}/>
        </Grid>
        <Grid
         item
         sm={12}
        >
          <main 
          className={clsx(classes.mainContent, {
            [classes.mainContentShift]: isOpen,
          })}
          >
              {props.children}
          </main>
        </Grid>
        <Grid
         item
         sm={12}
        >
          <Footer isOpen={isOpen}/>
        </Grid>
      </Grid>
    )
}

export default Layout