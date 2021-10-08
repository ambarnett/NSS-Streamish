import React, { useEffect, useState } from "react";
import { getAllVideos } from "../modules/videoManager";
import Video from "./Video";

const VideoList = () => {
    const [videos, setVideos] = useState([]);

    const getVideos = () => {
        getAllVideos().then(videos => setVideos(videos));
    };

    useEffect(() => {
        getVideos();
    }, [])

    return (
        <div className="container">
            <div className="row justify-content-center">
                {videos.map((v) => (
                    <Video video={v} key={v.id} />
                ))}
            </div>
        </div>
    );
};

export default VideoList;
