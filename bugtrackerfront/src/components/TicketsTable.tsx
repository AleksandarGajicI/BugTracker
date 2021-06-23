import {Grid, Paper, Table, TableBody, TableCell, TableContainer, TableFooter, TableHead, TableRow, TextField } from "@material-ui/core";
import { useState } from "react";
import { useEffect } from "react";
import { useHistory } from "react-router-dom";
import Actions from "./actions/Actions";
import { HeadersBuilder } from "./actions/HeadersBuilder";
import { ParamsBuilder } from "./actions/ParamsBuilder";
import Loading from "./Loading";
import { TicketAbbrevDTO } from "./models/dtos/TicketAbbrevDTO";
import Pagination from "./Pagination";

interface Props {
    withPagination: boolean,
}

function TicketsTable(props: Props) {

    const [tickets, setTickets] = useState<TicketAbbrevDTO[]>([])
    const [loading, setLoading] = useState<boolean>(false)
    const [pageNum, setPageNum] = useState<number>(1)
    const [searchText, setSearchText] = useState<string>("")
    const headerBuilder = new HeadersBuilder()
    const paramsBuilder = new ParamsBuilder()
    const history = useHistory()

    useEffect(() => {
        if(!localStorage.getItem("token")) {
            history.push("/")
        }

        setLoading(true)

        headerBuilder.resetHeaders()
        .addHeader("Authorization", `Bearer ${localStorage.getItem("token")}`)

        paramsBuilder
        .resetFilters()
        .resetParameters()
        .addParameter("PageSize", 3)
        .addParameter("PageNum", pageNum)

        if(searchText !== "") {
            paramsBuilder.addFilter("title", {property: "title", value: searchText})
        }

        Actions.TicketActions.page(paramsBuilder.makeUrlSearchParams(), headerBuilder.getHeaders())
        .then(data => {
            console.log(data)
            setTickets(data)
            setLoading(false)
        })
    }, [searchText, pageNum])

    function nextClicked() {
        if(tickets.length > 0) {
            setPageNum(pageNum + 1)
        }
    }

    function prevClicked() {
        if(pageNum > 1) {
            setPageNum(pageNum - 1)
        }
    }

    if(loading) {
        return (
            <Loading/>
        )
    }

    function redirect(id: string, e: any) {
        e.stopPropagation()

        history.push("tickets/" + id)

    }

    function handleInputChange(e: any) {
        if(e.key === "Enter") {
            console.log(e.target.value)
            setSearchText(e.target.value)
            console.log(searchText)
        }
    }

    return (
        <Grid
        container
        style={{backgroundColor: "#234"}}
        >
            <TableContainer 
            component={Paper}
            >
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell colSpan={2}/>
                            <TableCell colSpan={1} align="right">
                                
                                <TextField
                                id="filled-full-width"
                                label="Search for ticket by title"
                                style={{ margin: 8 }}
                                placeholder="Enter title"
                                fullWidth
                                margin="normal"
                                variant="outlined"
                                onKeyDown={(e) => handleInputChange(e)}
                                />
                            </TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell>Title:</TableCell>
                            <TableCell align="left">Status:</TableCell>
                            <TableCell align="center">Deadline:</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {tickets.length > 0 && tickets.map((ticket) => {
                            return (
                                <TableRow 
                                hover 
                                key={ticket.id}
                                onClick={(e) => redirect(ticket.id, e)}
                                >
                                    <TableCell component="th" scope="row">
                                    {ticket.title}
                                    </TableCell>
                                    <TableCell align="left">{ticket.status}</TableCell>
                                    <TableCell align="center">{ticket.deadline.toString().split("T")[0]}</TableCell>
                                </TableRow>
                            )
                        })}
                        {tickets.length <= 0 && 
                            <TableRow>
                                <TableCell colSpan={4}
                                align="center"
                                style={{color: "#E20B0B", fontSize: "1.2em"}}>No tickets</TableCell>
                            </TableRow>
                        }
                    </TableBody>
                    {props.withPagination && <TableFooter>
                        <TableRow>
                            <TableCell colSpan={6}>
                                <Pagination pageNum={1} onPrevClick={() => prevClicked()} onNextClick={() => nextClicked()}/>
                            </TableCell>
                        </TableRow>   
                    </TableFooter>}
                </Table> 
            </TableContainer>
        </Grid>
    )
}

export default TicketsTable