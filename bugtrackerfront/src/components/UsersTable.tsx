import { Button, Paper, Table, TableBody, TableCell, TableContainer, TableFooter, TableHead, TableRow } from "@material-ui/core";
import { useEffect, useRef, useState } from "react";
import { useHistory } from "react-router-dom";
import Actions from "./actions/Actions";
import { HeadersBuilder } from "./actions/HeadersBuilder";
import { ParamsBuilder } from "./actions/ParamsBuilder";
import Loading from "./Loading";
import { UserDTO } from "./models/dtos/UserDTO";
import Pagination from "./Pagination";



interface Props {
    searchText: string,
    onClick: (user: UserDTO) => void
}

function UsersTable(props: Props) {
    const [loading, setLoading] = useState<boolean>(false)
    const [users, setUsers] = useState<UserDTO[]>([])
    const [pageNum, setPageNum] = useState<number>(1)
    const history = useHistory()
    const headerBuilder = new HeadersBuilder()
    const paramsBuilder = new ParamsBuilder()
    const searchText = useRef(props.searchText)

    useEffect(() => {
        if(!localStorage.getItem("token")) {
            history.push("/")
        }
        console.log("please")
        if(searchText.current != props.searchText) {
            console.log("changedSearchText")
        }

        setLoading(true)

        headerBuilder.resetHeaders()
        .addHeader("Authorization", `Bearer ${localStorage.getItem("token")}`)

        paramsBuilder
        .addParameter("PageSize", 3)
        .addParameter("PageNum", pageNum)

        if(props.searchText != "") {
            paramsBuilder.addFilter("all", {property: "all", value: props.searchText })
        }

        Actions.UserActions.page(paramsBuilder.makeUrlSearchParams() , headerBuilder.getHeaders())
        .then(data => {
            console.log(data)
            setUsers(data)
            setLoading(false)
        })
        .catch(e => {
            console.log(e)
            setLoading(false)
        })
    }, [props.searchText, pageNum])


    function prevClicked() {
        if(pageNum > 1) {
            setPageNum(pageNum - 1)
        }
    }

    function nextClicked() {
        if(users.length > 0) {
            setPageNum(pageNum + 1)
        }
    }

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
                    {users.length > 0 && users.map((user) => {
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
                    {users.length <= 0 &&
                        <TableRow>
                            <TableCell 
                            colSpan={5} 
                            align="center"
                            style={{color: "#E20B0B", fontSize: "1.2em"}}
                            >
                                There are no search results!
                            </TableCell>
                        </TableRow>
                    }
                </TableBody>
                <TableFooter>
                    <TableRow>
                        <TableCell colSpan={6}>
                            <Pagination pageNum={pageNum} onPrevClick={() => prevClicked()} onNextClick={() => nextClicked()}/>
                        </TableCell>
                    </TableRow>   
                </TableFooter>
            </Table>
        </TableContainer>
    )
}

export default UsersTable