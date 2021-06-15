import { Button, Grid, InputAdornment, TextField, Typography } from "@material-ui/core";
import useStyles from "./style/MainStyle";
import EmailIcon from '@material-ui/icons/Email';
import LockIcon from '@material-ui/icons/Lock';
import AccountBoxIcon from '@material-ui/icons/AccountBox';
import { Link } from "react-router-dom";

function SignupPage() {
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
                src={process.env.PUBLIC_URL + "/assets/images/signUpTeamPicture.jpg"} 
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
                    <Typography variant="h6">Signup and begin your journey:</Typography>
                    <TextField 
                    label="Email" 
                    margin="normal"
                    style={{minWidth: "100%"}}
                    InputProps={{ startAdornment: <InputAdornment position="start"><EmailIcon/></InputAdornment>}}
                    />
                    <TextField 
                    label="Username" 
                    margin="normal"
                    style={{minWidth: "100%"}}
                    InputProps={{ startAdornment: <InputAdornment position="start"><AccountBoxIcon/></InputAdornment>}}
                    />
                    <TextField 
                    type="password"
                    label="Password" 
                    margin="normal"
                    style={{minWidth: "100%"}}
                    InputProps={{ startAdornment: <InputAdornment position="start"><LockIcon/></InputAdornment>}}

                    />
                    <TextField 
                    type="password"
                    label="Repeat Password" 
                    margin="normal"
                    style={{minWidth: "100%"}}
                    InputProps={{ startAdornment: <InputAdornment position="start"><LockIcon/></InputAdornment>}}

                    />
                    <Button 
                    color="primary" 
                    variant="contained"
                    style={{margin: "2em", minWidth: "100%"}}
                    >
                        Signup
                    </Button>
                    <Button
                     component={Link}
                     to="/login"
                    >
                        Already have an account? Click here
                    </Button>
                </div>
            </Grid>

        </Grid>
    )
}

export default SignupPage