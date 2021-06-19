import { createStyles } from "@material-ui/core";
import { Theme } from "@material-ui/core";
import makeStyles from "@material-ui/core/styles/makeStyles";

const drawerWidth = 240;

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    appBar: {
      zIndex: theme.zIndex.drawer + 1,
    },
    root: {
      display: "flex",
      //backgroundColor: "#f2f2f2",
    },
    menuButton: {
      marginRight: theme.spacing(2),
    },
    title: {
      flexGrow: 1,
    },
    drawer: {
      width: drawerWidth,
      flexShrink: 0,
    },
    drawerPaper: {
      width: drawerWidth,
    },
    mainContent: {
      flexGrow: 1,
      padding: theme.spacing(3),
      transition: theme.transitions.create("margin", {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.leavingScreen,
      }),
      marginLeft: 0,
      marginTop: 60,
    },
    mainContentShift: {
      transition: theme.transitions.create("margin", {
        easing: theme.transitions.easing.easeOut,
        duration: theme.transitions.duration.enteringScreen,
      }),
      marginLeft: drawerWidth,
    },
    pagination: {
      backgroundColor: "#CCCCCD",
    },
    formContainer: {
      margin: theme.spacing(5),
    },
    formRow: {
      margin: theme.spacing(2),
      width: "80%",
    },
    gridItemNoPadMarg: {
      [theme.breakpoints.down("sm")]: {
        margin: 0,
        "& > .MuiGrid-item": {
          padding: 0,
        },
      },
    },
    footerWrapper: {
      backgroundColor: "#11133C",
    },
    homePagePicture: {
      height: "100%",
      width: "100%",
      backgroundImage: `url(${
        process.env.PUBLIC_URL +
        "assets/images/bugTrackerHomePageBackground.png"
      })`,
      backgroundSize: "100% 100%",
    },
    homePageTitle: {
      color: "#ffffff",
    },
    expandMoreButton: {
      fontSize: "3em",
    },
    homePageWhyUs: {
      height: "100vh",
      width: "100%",
      padding: "5em",
    },
    whyUsCardView: {
      maxWidth: "300px",
    },
    whyUsCardViewMedia: {
      height: "12em",
    },
    loginContainer: {
      height: "100vh",
      width: "100%",
    },
    input: {
      color: "white",
    },
  })
);

export default useStyles;
