import Box from '@material-ui/core/Box';
import Collapse from '@material-ui/core/Collapse';
import IconButton from '@material-ui/core/IconButton';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Typography from '@material-ui/core/Typography';
import Paper from '@material-ui/core/Paper';
import KeyboardArrowDownIcon from '@material-ui/icons/KeyboardArrowDown';
import KeyboardArrowUpIcon from '@material-ui/icons/KeyboardArrowUp';
import { useState } from 'react';
import { ProjectUserReqDTO } from './models/dtos/ProjectUserReqDTO';
import { Button, Grid } from '@material-ui/core';
import { useEffect } from 'react';
import Actions from './actions/Actions';


function Row(props: {request: ProjectUserReqDTO, isOwner: boolean}) {    
    const [open, setOpen] = useState<boolean>(false)

    
    return (
        <>
        <TableRow>
        <TableCell>
          <IconButton aria-label="expand row" size="small" onClick={() => setOpen(!open)}>
            {open ? <KeyboardArrowUpIcon /> : <KeyboardArrowDownIcon />}
          </IconButton>
        </TableCell>
        <TableCell component="th" scope="row">
          {props.request.message ?? "No message"}
        </TableCell>
        <TableCell align="center">{props.request.invitedAt.split("T")[0]}</TableCell>
        <TableCell align="center">{props.request.project.name}</TableCell>
      </TableRow>
      <TableRow>
        <TableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={6}>
          <Collapse in={open} timeout="auto" unmountOnExit>
            <Box margin={1}>
              <Typography variant="h6" gutterBottom component="div">
                Details
              </Typography>
              <Table size="small" aria-label="purchases">
                <TableHead>
                  <TableRow>
                    {!props.isOwner
                    ? <TableCell>Sender</TableCell>
                    : <TableCell>Sent to</TableCell>
                    }
                    <TableCell>Role</TableCell>
                    <TableCell align="center">ProjectDeadline</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                    <TableRow key={props.request.id}>
                        <TableCell component="th" scope="row">
                        {props.request.user.userName}
                        </TableCell>
                        <TableCell>{props.request.role.roleName}</TableCell>
                        <TableCell align="center">{props.request.project.deadline.split("T")[0]}</TableCell>
                    </TableRow>
                    <TableRow>
                      <TableCell colSpan={2}/>
                      <TableCell 
                      colSpan={3} 
                      align="right">
                          {!props.isOwner && <Button 
                            variant="outlined" 
                            color="primary" 
                            size="small"
                            style={{margin: "0.5em"}}
                            >
                                ACCEPT
                          </Button>}
                          <Button 
                            variant="outlined" 
                            color="secondary" 
                            size="small"
                            style={{margin: "0.5em"}}
                            >
                                {!props.isOwner
                                ? "REJECT"
                              : "DELETE REQUEST"}
                          </Button>
                      </TableCell>
                    </TableRow>
                </TableBody>
              </Table>
            </Box>
          </Collapse>
        </TableCell>
      </TableRow>
      </>
    )
}


function RequestsTable(props: {isOwner: boolean}) {
    const [requests, setRequests] = useState<ProjectUserReqDTO[]>([])

    useEffect(() => {
        Actions.ProjectUserReqActions.all()
        .then(data => {
            setRequests(data)
        })
    }, [])

    return (
        <TableContainer component={Paper}>
      <Table aria-label="collapsible table">
        <TableHead>
          <TableRow>
            <TableCell />
            <TableCell>Message</TableCell>
            <TableCell align="center">Sent At</TableCell>
            <TableCell align="center">Project Name</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {requests.map((request) => (
            <Row key={request.id} request={request} isOwner={props.isOwner}/>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
    )

}

export default RequestsTable