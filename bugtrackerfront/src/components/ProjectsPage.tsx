import Layout from "./Layout";
import { Button, Grid, Typography } from '@material-ui/core';
import ProjectTable from './ProjectsTable';
import useStyles from './style/MainStyle';
import ProjectForm from './forms/ProjectForm';
import { useToggle } from './useToggle';

function ProjectsPage() {
    const classes = useStyles();
    const projectFormToggle = useToggle(false);


  function afterCreate() {
    projectFormToggle.toggle()
  }

    return (
        <Layout>
            <Grid
            container
            item
            xs={12}
            md={12}
            >
              <Grid 
              item
              container
              direction="row"
              alignItems="center"
              justify="space-between"
              className={classes.pagination}
              >
                <Typography 
                variant="h6"
                style={{margin: "2em"}}
                >
                  Welcome to Project page!
                  </Typography>
                <Button
                  color="secondary"
                  variant="outlined"
                  style={{margin: "2em"}}
                  onClick={() => projectFormToggle.toggle() }
                >
                  {projectFormToggle.isOpen === false
                  ? "MAKE NEW PROJECT"
                  : "CANCEL"
                  }
                </Button>
              </Grid>
              <Grid
              item
              xs={12}
              >
                {projectFormToggle.isOpen && <ProjectForm afterCreate={afterCreate}/>}
              </Grid>
              <Grid
              item
              xs={12}
              >
                <ProjectTable/>
              </Grid>
            </Grid>
        </Layout>
    )
}

export default ProjectsPage