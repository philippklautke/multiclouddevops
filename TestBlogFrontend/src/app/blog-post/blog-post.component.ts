import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BlogPost } from '../models/blogpost';
import { BlogPostService } from '../blog-post.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-blog-post',
  templateUrl: './blog-post.component.html',
  styleUrls: ['./blog-post.component.scss']
})
export class BlogPostComponent implements OnInit {
  blogPost$: Observable<BlogPost>;
  postId: number;
  constructor(private blogPostService: BlogPostService, private avRoute: ActivatedRoute) {
    const idParam = 'id';
    if(this.avRoute.snapshot.params[idParam]){
      this.postId = this.avRoute.snapshot.params[idParam];
    }
   }

  ngOnInit() {
    this.loadBlogPost();
  }
  loadBlogPost(){
    this.blogPost$ = this.blogPostService.getBlogPost(this.postId);
  }

}
