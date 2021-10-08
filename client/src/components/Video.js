import React from 'react';
import { Card, CardBody } from 'reactstrap';

const Video = ({video}) => {
    return (
        <Card >
            <p className="text-left px-2">Posted by: {video.userProfile.name}</p>
            <CardBody>
                <iframe className="video"
                src={video.url}
                title="YouTube video player"
                frameBorder="0"
                allow="accelerometer; autoplay; clipboard-write; encrypteed-media; gyroscope; picture-in-picture"
                allowFullScreen />
                <p>
                    <string>{video.title}</string>
                </p>
                <p>{video.description}</p>
                <h4>Comments: </h4>
                <Card className="border-3">{video.comments.map(c => <p>{c.message}</p>)}</Card>
            </CardBody>
        </Card>
    );
};

export default Video;