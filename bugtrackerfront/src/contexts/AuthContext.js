import React, {useContext, useEffect, useState} from 'react'
import { useHistory } from "react-router-dom";
import Actions from "../components/actions/Actions";

const AuthContext = React.createContext();

export function useAuth () {
    return useContext(AuthContext)
}   

export function AuthProvider({children}) {

    const [currentUser, setCurrentUser] = useState({})

    useEffect(() => {
        
        //treba da se stavi token u header
        // Actions.UserActions.getUserFromToken()
        // .then(res => {
        //     console.log(res);
        //     setCurrentUser(res);
        // })
        // .catch(err => {
        //     console.log(err);
        // })
    }, [])

    const value = {
        currentUser
    }

    return (
        <AuthContext.Provider value={value}>
            {children}
        </AuthContext.Provider>
    )
}
