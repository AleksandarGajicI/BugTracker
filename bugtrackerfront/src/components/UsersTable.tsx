import { Button, Paper, Table, TableBody, TableCell, TableContainer, TableFooter, TableHead, TableRow } from "@material-ui/core";
import { useHistory } from "react-router-dom";
import Pagination from "./Pagination";

interface UserDTO {
    id: string,
    name: string,
    email: string,
    joined: string,
    userName: string
}

const users: UserDTO[] = [
    {
        id: "1",
        name: "Name 1",
        email: "Email 1",
        joined: "10.10.2020",
        userName: "username1"
    },
    {
        id: "2",
        name: "Name 2",
        email: "Email 2",
        joined: "20.20.1010",
        userName: "username2"
    }
]

function UsersTable() {

    const history = useHistory()

    function redirect(id: string) {
        history.push("/users/invite/" + id)
    }

    return (
        <TableContainer 
         component={Paper}
        >
            <Table>
                <TableHead>
                    <TableRow>
                        <TableCell>UserName:</TableCell>
                        <TableCell align="center">Name:</TableCell>
                        <TableCell align="right">Email:</TableCell>
                        <TableCell align="right">Joined:</TableCell>
                        <TableCell align="right"></TableCell>
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
                                <TableCell align="right">{user.joined.toString().split("T")[0]}</TableCell>
                                <TableCell align="right">
                                    <Button 
                                    color="primary"
                                    onClick={() => redirect(user.id)}
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