import React from 'react';
import { useParams } from 'react-router-dom';
import posts from '../data/posts'; // Import the posts data

const BlogPostDetails = () => {
  const { postId } = useParams(); // Get the postId from the URL
  const post = posts[postId]; // Retrieve the post data

  console.log('Post ID:', postId); // Debug: Check the postId
  console.log('Post Data:', post); // Debug: Check the post data

  // If postId does not exist in the data, show a 404 message
  if (!post) {
    return (
      <div className="container">
        <h2>Post Not Found</h2>
        <p>Sorry, this post does not exist.</p>
      </div>
    );
  }

  return (
    <div className="container">
      <h2>{post.title}</h2>
      {post.image && <img src={post.image} alt={post.title} className="blog-image" />}
      <p>{post.content}</p>
    </div>
  );
};

export default BlogPostDetails;
