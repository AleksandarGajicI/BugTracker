import { Button, Grid, InputAdornment, TextField, Typography } from "@material-ui/core";
import useStyles from "./style/MainStyle";
import EmailIcon from '@material-ui/icons/Email';
import LockIcon from '@material-ui/icons/Lock';
import { Link } from "react-router-dom";

function LoginPage() {
    const classes = useStyles()

    return (
        <Grid
         container
         className={classes.loginContainer}
        >
            <Grid 
            item 
            xs={12}
            sm={6}
            >
                <img 
                src={process.env.PUBLIC_URL + "/assets/images/loginPageBackground.jpg"} 
                style={{width: "100%", maxHeight: "100vh", objectFit: "cover"}}
                alt="brand"
                />
            </Grid>
            <Grid
            item
            container
            xs={12}
            sm={6}
            alignItems="center"
            direction="column"
            justify="space-evenly"
            >
                <div style={{
                    display: "flex", 
                    flexDirection: "column", 
                    alignItems: "center", 
                    minWidth: 300, 
                    maxWidth: 300
                }}>
                    {/* <Grid
                     container
                     justify="center"
                    ></Grid> */}
                    <Typography variant="h6">Login here:</Typography>
                    <TextField 
                    label="Email" 
                    margin="normal"
                    style={{minWidth: "100%"}}
                    InputProps={{ startAdornment: <InputAdornment position="start"><EmailIcon/></InputAdornment>}}
                    />
                    <TextField 
                    type="password"
                    label="Password" 
                    margin="normal"
                    style={{minWidth: "100%"}}
                    InputProps={{ startAdornment: <InputAdornment position="start"><LockIcon/></InputAdornment>}}

                    />
                    <Button 
                    color="primary" 
                    variant="contained"
                    style={{margin: "2em", minWidth: "100%"}}
                    >
                        Login
                    </Button>
                    <Button
                     component={Link}
                     to="/signup"
                    >
                        Interested in joining?
                    </Button>
                </div>
            </Grid>

        </Grid>
    )
}

export default LoginPage