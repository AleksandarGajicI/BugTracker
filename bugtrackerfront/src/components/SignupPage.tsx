import { Button, Grid, InputAdornment, TextField, Typography, makeStyles } from "@material-ui/core";
import useStyles from "./style/MainStyle";
import EmailIcon from '@material-ui/icons/Email';
import LockIcon from '@material-ui/icons/Lock';
import AccountBoxIcon from '@material-ui/icons/AccountBox';
import {useForm} from "../components/useForm"
import { Link } from "react-router-dom";    
import React, {useState} from 'react'
import Actions from "./actions/Actions"
import { UserCreationDTO } from "./models/dtos/UserCreationDTO";
import {useAuth} from '../contexts/AuthContext';


const initial: UserCreationDTO = {
    userName: "",
    password: "",
    email: "",
    firstName: "",
    lastName: ""
}

const initialFieldValues = {
    userName: "",
    password: "",
    repeatPassword: "",
    email: "",
    firstName: "",
    lastName: ""
}


const useCustomStyles = makeStyles((theme) => ({
    errorParagraph: {
        color: "#DC143C"
    }
}))

function SignupPage() {
    const {currentUser, setCurrentUser} = useAuth();
    const customClasses = useCustomStyles()
    const classes = useStyles()
    //const [user, setUser] = useState<UserCreationDTO>(initial)
    const [signUpError, setSignUpError] = useState("");
    const {values, handleInputChange, errors, setErrors} = useForm(initialFieldValues);

    const validate = () => {
        setSignUpError('');
        let temp = {
            userName: "",
            password: "",
            repeatPassword: "",
            email: "",
            firstName: "",
            lastName: ""
        }
        temp.firstName = values.firstName?"":"This field is required"
        temp.lastName = values.lastName?"":"This field is required"
        temp.email = ((/$^|.+@.+..+/).test(values.email) && values.email.length!=0)?"":"Email is not valid"
        temp.userName = values.userName.length>3?"":"Minimum 4 characters required"
        temp.password = values.password.length !== 0?"":"This field is required"
        if(temp.password === "" && values.password !== values.repeatPassword){
            setSignUpError("Passwords do not match");
            return false;
        } else {
            setSignUpError('');
        }
        setErrors({
            ...temp
        })
        console.log(temp)
        return Object.values(temp).every(x=> x === "");
    }


    const handleSubmit = (e:any) => {
        e.preventDefault();
        if(validate()){
            const user = {
                userName: values.userName,
                password: values.password,
                email: values.email,
                firstName: values.firstName,
                lastName: values.lastName
            }
            console.log(values);
            Actions.UserActions.create(user)
            .then(res => {
                console.log(res);
                setCurrentUser(res);
                localStorage.setItem('token', res.bugTrackerToken);
            })
            .catch(err => {
                console.log(err);
            });
        }
       

    }

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
                style={{width: "100%", minHeight: "100vh", objectFit: "cover"}}
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
                <form onSubmit={handleSubmit}>
                    <Typography variant="h6">Signup and begin your journey:</Typography>
                    <TextField 
                    label="First Name"
                    name="firstName"
                    {...(errors.firstName && {error:true, helperText:errors.firstName})}
                    value={values.firstName} 
                    onChange={handleInputChange}
                    margin="normal"
                    style={{minWidth: "100%"}}
                    />
                    <TextField 
                    label="Last Name"
                    name="lastName"
                    {...(errors.lastName && {error:true, helperText:errors.lastName})}
                    value={values.lastName} 
                    margin="normal"
                    onChange={handleInputChange}
                    style={{minWidth: "100%"}}
                    />
                    <TextField 
                    label="Email"
                    name="email"
                    {...(errors.email && {error:true, helperText:errors.email})}
                    value={values.email} 
                    margin="normal"
                    onChange={handleInputChange}
                    style={{minWidth: "100%"}}
                    InputProps={{ startAdornment: <InputAdornment position="start"><EmailIcon/></InputAdornment>}}
                    />
                    <TextField 
                    label="Username"
                    name="userName"
                    {...(errors.userName && {error:true, helperText:errors.userName})}
                    value={values.userName}
                    margin="normal"
                    onChange={handleInputChange}
                    style={{minWidth: "100%"}}
                    InputProps={{ startAdornment: <InputAdornment position="start"><AccountBoxIcon/></InputAdornment>}}
                    />
                    <TextField 
                    type="password"
                    label="Password"
                    onChange={handleInputChange}
                    name="password"
                    {...(errors.password && {error:true, helperText:errors.password})}
                    value={values.password}  
                    margin="normal"
                    style={{minWidth: "100%"}}
                    InputProps={{ startAdornment: <InputAdornment position="start"><LockIcon/></InputAdornment>}}

                    />
                    <TextField 
                    type="password"
                    label="Repeat Password" 
                    name="repeatPassword"
                    error={errors.repeatPassword}
                    onChange={handleInputChange}
                    value={values.repeatPassword} 
                    margin="normal"
                    style={{minWidth: "100%"}}
                    InputProps={{ startAdornment: <InputAdornment position="start"><LockIcon/></InputAdornment>}}

                    />
                    {signUpError && <p className={customClasses.errorParagraph}>{signUpError}</p>}
                    <Button 
                    color="primary" 
                    variant="contained"
                    type="submit"
                    style={{marginTop: "2em", marginBottom: "2em", minWidth: "100%"}}
                    >
                        Signup
                    </Button>
                    <Button
                     component={Link}
                     to="/login"
                    >
                        Already have an account? Click here
                    </Button>
                </form>
                </div>
            </Grid>

        </Grid>
    )
}

export default SignupPage