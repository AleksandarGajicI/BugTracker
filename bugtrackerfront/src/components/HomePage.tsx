import { Button, Collapse, Grid, IconButton, Typography } from '@material-ui/core';
import useStyles from "./style/MainStyle"
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';
import { useEffect, useRef, useState } from 'react';
import WhyUsCardView from './WhyUsCardView';
import Footer from './Footer';
import { Link } from 'react-router-dom';

interface WhyUsCards {
    title: String,
    description: String,
    url: string
}

const whyUsCards: WhyUsCards[] = [
    {
        title: "Track Bug/Errors in your project", 
        description: "Help your team keep track of every bug on their projects, by having them all in one place!",
        url: `${process.env.PUBLIC_URL + "/assets/images/programming-error-bug.jpg"}`
    },
    {
        title: "Responsibility Management", 
        description: "Knowing who is responsible for fixing which bug is important, thats why we make it easy and our priority",
        url: `${process.env.PUBLIC_URL + "/assets/images/responsibility.jpg"}`
    },
    {
        title: "Track requested features", 
        description: "If you want an easy way to keep track of any features that need to be done on projects, we are here for you",
        url: `${process.env.PUBLIC_URL + "/assets/images/features.jpg"}`
    }
]

function HomePage() {
    const classes = useStyles()
    const [checked, setChecked] = useState(false)
    const whyUsDiv = useRef<HTMLDivElement>(null)

    useEffect(() => {
        setChecked(true)
    }, [])


    return (
        <Grid
         container
         direction="row"
        >
            <Grid
             item
             container
             style={{height: "100vh"}}
             alignItems="center"
             justify="center"
             className={classes.homePagePicture}
            >
                <Grid
                 item
                 container 
                 alignItems="center"
                 justify="center"
                >
                    <Collapse 
                     in={checked}
                     {...(checked ? { timeout: 1000 } : {})}
                    >
                    <Grid
                     item
                     container
                     alignItems="center"
                     justify="center"
                     direction="column"
                    >
                        <Typography 
                        style={{
                            color: "#fff", 
                            textShadow: "-1px 0 black, 0 1px black, 1px 0 black, 0 -1px black",
                        }}
                        variant="h1"
                        >
                            Gets Things Done
                        </Typography>
                        <Typography 
                        style={{
                            color: "#fff", 
                            textShadow: "-1px 0 black, 0 1px black, 1px 0 black, 0 -1px black",
                            width: "80vw"
                        }}
                        variant="h4"
                        align="center"
                        >
                            Help your project, by helping your team keep track of Bugs, Feature Requests and more!
                        </Typography>
                        <Button 
                         size="large"
                         variant="contained"
                         color="primary"
                         style={{margin: "2em"}}
                         component={Link}
                         to="/signup"
                        > Get Started</Button>
                        
                    <IconButton 
                    color="primary"
                     onClick={() => {whyUsDiv.current?.scrollIntoView({behavior: "smooth"})}}
                    >
                            <ExpandMoreIcon className={classes.expandMoreButton}/>
                    </IconButton>
                    </Grid>
                    </Collapse>
                </Grid>
            </Grid>
            <Grid
            item
            container
            className={classes.homePageWhyUs}
            ref={whyUsDiv}
            alignItems="center"
            justify="space-around"
            style={{backgroundColor: "#DEDEDE"}}
            >
                {whyUsCards.map((card, index) => {
                    return (
                        <Grid
                        item
                        container   
                        justify="center"
                        xs={12}
                        md={6}
                        lg={3}
                        style={{height: "fit-content"}}
                        >
                            
                            <WhyUsCardView
                            title={card.title}
                            description={card.description}
                            url = {card.url}
                            />
                        </Grid>
                    )
                })}
            </Grid>
            <Grid
            item
            container
            style={{backgroundColor: "#DEDEDE"}}
            >
                <Footer isOpen={false}/>
            </Grid>
        </Grid>
    )
}

export default HomePage