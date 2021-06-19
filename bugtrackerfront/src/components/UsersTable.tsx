import { Button, Paper, Table, TableBody, TableCell, TableContainer, TableFooter, TableHead, TableRow } from "@material-ui/core";
import { useEffect } from "react";
import { useState } from "react";
import Actions from "./actions/Actions";
import Loading from "./Loading";
import { UserDTO } from "./models/dtos/UserDTO";
import Pagination from "./Pagination";



interface Props {
    onClick: (user: UserDTO) => void
}

function UsersTable(props: Props) {

    const [users, setUsers] = useState<UserDTO[]>([])
    const [loading, setLoading] = useState<boolean>(false)

    useEffect(() => {
        setLoading(true)
        Actions.UserActions.all()
        .then(data => {
            console.log(data)
            setUsers(data)
            setLoading(false)
        })
        .catch(e => {
            console.log(e)
            setLoading(false)
        })
    }, [])


    if(loading) {
        return (
            <Loading/>
        )
    }
    return (
        <TableContainer 
         component={Paper}
        >
            <Table>
                <TableHead>
                    <TableRow
                    style={{backgroundColor: "#3f51b5",}}
                    >
                        <TableCell style={{color: "#fff"}}>UserName:</TableCell>
                        <TableCell style={{color: "#fff"}} align="center">Name:</TableCell>
                        <TableCell style={{color: "#fff"}} align="center">Email:</TableCell>
                        <TableCell style={{color: "#fff"}} align="center">Joined:</TableCell>
                        <TableCell align="center"></TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {users.map((user) => {
                        return (
                            <TableRow 
                            hover 
                            key={user.id}
                            >
                                <TableCell component="th" scope="row">
                                {user.userName}
                                </TableCell>
                                <TableCell align="center">{user.name}</TableCell>
                                <TableCell align="center">{user.email}</TableCell>
                                <TableCell align="center">{user.joined.toString().split("T")[0]}</TableCell>
                                <TableCell align="right">
                                    <Button 
                                    color="primary"
                                    onClick={() => props.onClick(user)}
                                    >
                                        INVITE USER
                                    </Button>
                                </TableCell>
                            </TableRow>
                        )
                    })}
                </TableBody>
                <TableFooter>
                    <TableRow>
                        <TableCell colSpan={6}>
                            <Pagination pageNum={1} onPrevClick={() => console.log("prev")} onNextClick={() => console.log("next")}/>
                        </TableCell>
                    </TableRow>   
                </TableFooter>
            </Table>
        </TableContainer>
    )
}

export default UsersTable