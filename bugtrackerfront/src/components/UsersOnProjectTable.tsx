import { Button, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableFooter, TableHead, TableRow } from "@material-ui/core";
import { useHistory } from "react-router-dom";
import { UserOnProjectDTO } from "./models/dtos/UserOnProjectDTO";


const users: UserOnProjectDTO[] = [
    {
        id: "1",
        userName: "UserName 1",
        role: "Role 1",
        invitedAt: "20.20.2021",
        invitedBy: "Me"
    },
    {
        id: "2",
        userName: "UserName 2",
        role: "Role 2",
        invitedBy: "Me",
        invitedAt: "02.12.2021",
    }
]

interface Props {
    users: UserOnProjectDTO[]
}

function UsersOnProjectTable(props: Props) {
    const history = useHistory()

    return (
        <TableContainer 
         component={Paper}
        >
            <Table>
                <TableHead>
                    <TableRow>
                        <TableCell>UserName</TableCell>
                        <TableCell align="center">Role</TableCell>
                        <TableCell align="right">InvitedBy</TableCell>
                        <TableCell align="right">InvitedAt</TableCell>
                        <TableCell align="right"></TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {props.users.map(user => {
                        return(
                            <TableRow 
                            hover 
                            key={user.id}
                            >
                                <TableCell 
                                component="th" 
                                scope="row"
                                style={{fontSize: "0.75em"}}
                                >
                                    {user.userName}
                                </TableCell>
                                <TableCell 
                                align="center"
                                style={{fontSize: "0.75em"}}
                                >
                                    {user.role}
                                </TableCell>
                                <TableCell 
                                align="center"
                                style={{fontSize: "0.75em"}}
                                >
                                    {user.invitedBy}
                                </TableCell>
                                <TableCell 
                                align="right"
                                style={{fontSize: "0.75em"}}
                                >
                                    {user.invitedAt.toString().split("T")[0]}
                                </TableCell>
                                <TableCell align="right">
                                    <Button color="secondary">DELETE</Button>
                                </TableCell>
                            </TableRow>
                        )
                    })
                    }
                </TableBody>
                <TableFooter>
                    <TableRow>
                        <TableCell colSpan={12}>
                            <Grid
                            container
                            justify="center">
                                <Button 
                                color="primary" 
                                variant="contained"
                                onClick={() => {history.push("/users")}}
                                >ADD USER TO PROJECT</Button>
                            </Grid>
                        </TableCell>
                    </TableRow>   
                </TableFooter>
            </Table>
        </TableContainer>
    )
}

export default UsersOnProjectTable