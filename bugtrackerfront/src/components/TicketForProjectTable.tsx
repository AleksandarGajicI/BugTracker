import { 
    Button, 
    Paper, 
    Table, 
    TableBody, 
    TableCell, 
    TableContainer,
    TableFooter, 
    TableHead, 
    TableRow 
} from "@material-ui/core";
import { TicketForProjectDTO } from "./models/dtos/TicketForProjectDTO";




const tickets: TicketForProjectDTO[] = [
    {
        id: "1",
        title: "Ticket 1",
        deadline: "20.20.2022",
        type: "BUG_ERROR",
        status: "ONGOING"
    },
    {
        id: "2",
        title: "Ticket 2",
        deadline: "20.20.2022",
        type: "BUG_ERROR",
        status: "REVIEW"
    }
]

interface Props {
    tickets: TicketForProjectDTO[]
}

function TicketForProjectTable(props: Props) {
    return (
        <TableContainer 
         component={Paper}
        >
            <Table>
                <TableHead>
                    <TableRow>
                        <TableCell>Title</TableCell>
                        <TableCell align="center">Type</TableCell>
                        <TableCell align="right">Status</TableCell>
                        <TableCell align="right">Deadline</TableCell>
                        <TableCell align="right"></TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {props.tickets.map(ticket => {
                        return(
                            <TableRow 
                            hover 
                            key={ticket.id}
                            >
                                <TableCell 
                                component="th" 
                                scope="row"
                                style={{fontSize: "0.75em"}}
                                >
                                    {ticket.title}
                                </TableCell>
                                <TableCell 
                                align="center"
                                style={{fontSize: "0.75em"}}
                                >
                                    {ticket.type}
                                </TableCell>
                                <TableCell 
                                align="center"
                                style={{fontSize: "0.75em"}}
                                >
                                    {ticket.status}
                                </TableCell>
                                <TableCell 
                                align="right"
                                style={{fontSize: "0.75em"}}
                                >
                                    {ticket.deadline.toString().split("T")[0]}
                                </TableCell>
                                <TableCell align="right">
                                    <Button color="secondary">CLOSE</Button>
                                </TableCell>
                            </TableRow>
                        )
                    })
                    }
                </TableBody>
                <TableFooter>
                    <TableRow>
                        <TableCell colSpan={6}>
                            TODO: Botton to add user to project
                        </TableCell>
                    </TableRow>   
                </TableFooter>
            </Table>
        </TableContainer>
    )
}

export default TicketForProjectTable